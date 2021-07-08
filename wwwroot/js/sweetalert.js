function AddToCartSuccess() {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 1200
    });
    Toast.fire({
        icon: 'success',
        title: 'Items is added to cart'
    });
}


function NeedItemInCart() {
    Swal.fire({
        icon: 'error',
        title: 'Oops! Cart is empty!',
        showConfirmButton: false,
        timer: 1300,
        text: 'You need to put item to cart to process checkout.',
    })
}


function AddItemToWishList() {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 1200,
        iconColor: '#d47bcf',
    });
    Toast.fire({
        icon: 'success',
        title: 'Item is added to your wishlist'
    });
}


function DupplicateSlug() {
    Swal.fire({
        icon: 'error',
        title: 'Oops! You can not use this title/name!',
        showConfirmButton: false,
        timer: 1300,
        text: 'You need to enter a different Title/Name',
    })
}


function SomethingWentWrong() {
    Swal.fire({
        icon: 'error',
        title: 'Oops! Something went wrong!',
        showConfirmButton: false,
        timer: 1300,
        text: 'Check with Dev team to resolve this error',
    })
}

function AddingSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Yay! Success!',
        showConfirmButton: false,
        timer: 1300
    })
}

function AddingCommentSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Wow! You just added a comment!',
        showConfirmButton: false,
        timer: 1300
    })
}

function AddingReview() {
    Swal.fire({
        icon: 'success',
        title: 'Thank you for your review!',
        showConfirmButton: false,
        timer: 1300
    })
}

function UpdateOrderSuccess() {
    Swal.fire({
        icon: 'success',
        title: 'Update Order Success!',
        showConfirmButton: false,
        timer: 1200
    })
}



