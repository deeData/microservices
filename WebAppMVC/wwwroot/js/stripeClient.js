// A reference to Stripe.js initialized with your real test publishable API key.
var stripe = Stripe("pk_test_iJIKag44gtZYLPOvNj6bLCJH");


var callStripe = function (amount) {
    // Disable the button until we have Stripe set up on the page
    // The items the customer wants to buy
    var purchase = {
        items: [{ id: "item", amount: amount }]
    };

    $("button").disabled = true;
    fetch( billingApiUrl + "/secret", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(purchase)
    })
        .then(function (result) {
            return result.json();
        })
        .then(function (data) {
            var elements = stripe.elements();

            var style = {
                base: {
                    color: "#32325d",
                    fontFamily: 'Arial, sans-serif',
                    fontSmoothing: "antialiased",
                    fontSize: "16px",
                    "::placeholder": {
                        color: "#32325d"
                    }
                },
                invalid: {
                    fontFamily: 'Arial, sans-serif',
                    color: "#fa755a",
                    iconColor: "#fa755a"
                }
            };

            var card = elements.create("card", { style: style });
            // Stripe injects an iframe into the DOM
            card.mount("#card-element");

            card.on("change", function (event) {
                // Disable the Pay button if there are no card details in the Element
                $("button").disabled = event.empty;
                $("#card-error").textContent = event.error ? event.error.message : "";
            });

            var form = document.getElementById("payment-form");
            form.addEventListener("submit", function (event) {
                event.preventDefault();
                // Complete payment when the submit button is clicked
                payWithCard(stripe, card, data.clientSecret, amount);
            });
            setUpmessage(data.clientSecret, amount);

        });
};


// Calls stripe.confirmCardPayment
// If the card requires authentication Stripe shows a pop-up modal to
// prompt the user to enter authentication details without leaving your page.
var payWithCard = function (stripe, card, clientSecret, amount) {
    loading(true);
    stripe
        .confirmCardPayment(clientSecret, {
            payment_method: {
                card: card
            }
        })
        .then(function (result) {
            if (result.error) {
                // Show error to your customer
                showError(result.error.message);

            } else {
                // The payment succeeded!
                orderComplete(result.paymentIntent.id, amount);
            }
        });
};

/* ------- UI helpers ------- */

// Shows a success message when the payment is complete
var orderComplete = function (paymentIntentId, amount) {
    loading(false);
    document
        .querySelector(".result-message a")
        .setAttribute(
            "href",
            "https://dashboard.stripe.com/test/payments/" + paymentIntentId
        );
    $(".result-message").removeClass("hidden");
    $("button").disabled = true;
    mockWebhookPaymentUpdate(amount);
};

// Show the customer the error from Stripe if their card fails to charge
var showError = function (errorMsgText) {
    loading(false);
    $('#stripeResponse').text(errorMsgText);
};

// Show a spinner on payment submission
var loading = function (isLoading) {
    if (isLoading) {
        // Disable the button and show a spinner
        $("button").disabled = true;
        $("#spinner").removeClass("hidden");
        $("#button-text").addClass("hidden");
    } else {
        $("button").disabled = false;
        $("#spinner").addClass("hidden");
        $("#button-text").removeClass("hidden");
    }
};



//------------------------my edits/addons-----------------------------
function mockWebhookPaymentUpdate(amount) {
    var jsonItem = {};
    jsonItem.credit = amount;
    jsonItem.user = $('#userId').attr('value');
    $.ajax({
        type: "POST",
        data: JSON.stringify(jsonItem),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        url: billingApiUrl + "/mock-webhook",
        success: function (result) {
            jsonData.push(result);
            var $table = $('#dataTable');
            runningTotal = 0;
            $table.bootstrapTable('load', jsonData);
            var message = "$" + result['credit'] + " payment applied " + "from Card XXXX (mock-webhook cannot provide last 4 digits).";
            generalMessage(message, 'bg-primary');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR, textStatus, errorThrown);
        }
    });
}



var spanString = ' text-light font-weight-bold card-text" id = "stripeResponse" ></span>';
//var $stripe = $("#stripeResponse");

var setUpmessage = function (clientToken, amount) {
    var message = "Payment of $"+amount+" is ready to be processed (with Stripe client token).";
    var backgroundColor = "bg-info";
    if (clientToken) {
        $("#stripeResponse").replaceWith('<span class=" ' + backgroundColor + spanString);
        $("#stripeResponse").text(message);
        $("#stripeResponseTime").text(dateTimeStamp(new Date()));
    }
};

var generalMessage = function (message, backgroundColor) {
    $("#stripeResponse").replaceWith('<span class=" ' + backgroundColor + spanString);
    $("#stripeResponse").text(message);
    $("#stripeResponseTime").text(dateTimeStamp(new Date()));
};

//model required by Stripe
//var purchase = {
//    items: [{ id: "xl-tshirt", amount: 2 }]
//};
var purchase1 = { items: [] };

$("#submitAmt").click(function () {
    $pay = $('#payAmount');
    var amount = $pay.val();
    purchase1.items.push({ id: "item", amount: amount });
    console.log(purchase1);
    $pay.prop('disabled', true);
    $("#submittedMessage").html("Amount Submitted:");
    $("#submitAmt").hide();
    callStripe(amount);
    $("#stripeWidget").fadeIn();

});