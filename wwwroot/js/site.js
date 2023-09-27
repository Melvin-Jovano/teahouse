function addTea(e) {
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
}

function addRecipe(e) {
    e.preventDefault();

    if($("input[name='Recipe-Id']").val().length > 0) {
        return updateRecipe();
    }

    const formData = {
        Quantity: $("input[name='Recipe-Quantity']").val(),
        TeaId: $("select[name='Recipe-TeaId']").val(),
        IngredientId: $("select[name='Recipe-IngredientId']").val(),
    };

    $.ajax({
        url: "/Recipe/AddRecipe",
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
}

function updateRecipe() {
    const formData = {
        Id: $("input[name='Recipe-Id']").val(),
        TeaId: $("select[name='Recipe-TeaId']").val(),
        IngredientId: $("select[name='Recipe-IngredientId']").val(),
        Quantity: $("input[name='Recipe-Quantity']").val()
    };

    $.ajax({
        url: `/Recipe/UpdateRecipe`,
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

function deleteRecipe(id) {
    const isDelete = confirm('Delete this recipe?');

    if(isDelete) {
        $.ajax({
            url: `/Recipe/DeleteRecipe/${id}`,
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

function setRecipe(recipe) {
    $("input[name='Recipe-Id']").val(recipe.Id);
    $("input[name='Recipe-TeaId']").val(recipe.TeaId);
    $("input[name='Recipe-IngredientId']").val(recipe.IngredientId);
    $("input[name='Recipe-Quantity']").val(recipe.Quantity);
    $("#unselect-recipe-button").removeClass("d-none");
}

function unselectTea() {
    $("input[name='Tea-Id']").val('');
    $("input[name='Tea-Name']").val('');
    $("textarea[name='Tea-Description']").val('');
    $("input[name='Tea-Price']").val('');
    $("select[name='Tea-DrinkType']").val('');
    $("#unselect-tea-button").addClass("d-none");
}

function unselectRecipe() {
    $("input[name='Recipe-Id']").val('');
    $("input[name='Recipe-TeaId']").val('');
    $("textarea[name='Recipe-IngredientId']").val('');
    $("input[name='Recipe-Quantity']").val('');
    $("#unselect-recipe-button").addClass("d-none");
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