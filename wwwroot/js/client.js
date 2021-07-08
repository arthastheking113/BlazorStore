// Create an instance of the Stripe object with your publishable API key
function processToCheckOut(){
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Alright! You almost get there.',
        showConfirmButton: false,
        timer: 1300
    })
    setTimeout(function () {
        var stripe = Stripe("pk_test_51IVu6KI523rItHV0YnaAGZgGZK15dNf1yyxu4movfiY9niNYh1rx6PYUasMsx9z10NZ0MVwXVpmmxIXjYK3fxml700pxcHX3Yz");
        fetch("/create-checkout-session", {
            method: "POST",
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (session) {
                return stripe.redirectToCheckout({ sessionId: session.id });
            })
            .then(function (result) {
                // If redirectToCheckout fails due to a browser or network
                // error, you should display the localized error message to your
                // customer using error.message.
                if (result.error) {
                    alert(result.error.message);
                }
            })
            .catch(function (error) {
                console.error("Error:", error);
            });
    }, 500);
    
};
