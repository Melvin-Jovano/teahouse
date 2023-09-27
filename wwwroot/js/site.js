$(document).ready(function () {
    $("#add-tea-form").submit(function (e) {
        e.preventDefault();

        if($("input[name='Tea-Id']").val().length > 0) {
            return updateTea();
        }

        const formData = {
            Name: $("input[name='Tea-Name']").val(),
            Description: $("textarea[name='Tea-Description']").val(),
            DrinkType: $("select[name='Tea-DrinkType']").val(),
            Price: $("input[name='Tea-Price']").val()
        };

        $.ajax({
            url: "/Tea/AddTea",
            type: "POST",
            data: formData,
            success: function (result) {
                alert('Success');
                location.reload();
            },
            error: function (error) {
                alert('Error');
            }
        });
    });
});

function deleteTea(id) {
    const isDelete = confirm('Delete this tea?');

    if(isDelete) {
        $.ajax({
            url: `/Tea/DeleteTea/${id}`,
            type: "DELETE",
            success: function (result) {
                alert('Success');
                location.reload();
            },
            error: function (error) {
                alert('Error');
            }
        });
    }
}

function setTea(tea) {
    $("input[name='Tea-Id']").val(tea.Id);
    $("input[name='Tea-Name']").val(tea.Name);
    $("input[name='Tea-Name']").val(tea.Name);
    $("textarea[name='Tea-Description']").val(tea.Description);
    $("input[name='Tea-Price']").val(tea.Price);
    $("select[name='Tea-DrinkType']").val(tea.DrinkType);
    $("#unselect-tea-button").removeClass("d-none");
}

function unselect() {
    $("input[name='Tea-Id']").val('');
    $("input[name='Tea-Name']").val('');
    $("input[name='Tea-Name']").val('');
    $("textarea[name='Tea-Description']").val('');
    $("input[name='Tea-Price']").val('');
    $("select[name='Tea-DrinkType']").val('');
    $("#unselect-tea-button").addClass("d-none");
}

function updateTea() {
    const formData = {
        Id: $("input[name='Tea-Id']").val(),
        Name: $("input[name='Tea-Name']").val(),
        Description: $("textarea[name='Tea-Description']").val(),
        DrinkType: $("select[name='Tea-DrinkType']").val(),
        Price: $("input[name='Tea-Price']").val()
    };

    $.ajax({
        url: `/Tea/UpdateTea`,
        type: "PUT",
        data: formData,
        success: function (result) {
            alert('Success');
            location.reload();
        },
        error: function (error) {
            alert('Error');
        }
    });
}

function buyIngredient(id, stock) {
    const formData = {
        Id: id,
        Stock: stock
    };

    $.ajax({
        url: `/Ingredient/BuyIngredient`,
        type: "PUT",
        data: formData,
        success: function (result) {
            location.reload();
        },
        error: function (error) {
            alert('Error');
        }
    });
}