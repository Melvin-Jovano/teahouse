function logout() {
    if(confirm('Logout?')) {
        $.ajax({
            url: `/Auth/LogoutUser`,
            type: "DELETE",
            success: function (result) {
                location.href = '/Auth/Login';
            },
            error: function (error) {
                alert('Error');
            }
        });
    }
}