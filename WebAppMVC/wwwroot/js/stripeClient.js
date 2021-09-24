// A reference to Stripe.js initialized with your real test publishable API key.
var stripe = Stripe("pk_test_iJIKag44gtZYLPOvNj6bLCJH");

var callStripe = function (amount) {
    // Disable the button until we have Stripe set up on the page
    // The items the customer wants to buy
    var purchase = {
        items: [{ id: "item", amount: amount }]
    };

    $("button").disabled = true;
    fetch("https://localhost:44372/api/payment/secret", {
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
    paymentMessage(amount);
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



//------------------------my edits-addons-----------------------------
var setUpmessage = function (clientToken, amount) {
    if (clientToken) {
        $("#stripeResponse").text("$" + amount + " payment is ready to be processed with Stripe client token.   ");
        $("#stripeResponseTime").text(dateTimeStamp(new Date()));
    }
};

var paymentMessage = function (amount) {
    var message = "Success: Payment of $" + amount + " has been posted to the billing ledger.   ";
    $("#stripeResponse").text(message);
    $("#stripeResponseTime").text(dateTimeStamp(new Date()));
};