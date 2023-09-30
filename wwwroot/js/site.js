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

function randomFromArray(array) {
    return array[Math.floor(Math.random() * array.length)];
}

function getRandomName() {
    return randomFromArray([
        "Miss Simian",
        "Felis Catus The III",
        "Sir Orca",
        "Duchess Purrington",
        "Captain Quokka",
        "Lady Chinchilla",
        "Professor Wombat",
        "Baron Von Hedgehog",
        "Countess Meerkat",
        "Sir Llama Llama Ding Dong",
        "Queen Koala",
        "King Penguin McFluff",
        "Lord Alpaca",
        "Lady Flamingo Fluffington",
        "Admiral Axolotl",
        "Prince Puffin Paws",
        "Empress Emu",
        "Duke Armadillo",
        "Ladybug Ladybug",
        "Baroness Bunny Bounce",
        "Sir Slothington",
        "Madame Manatee",
        "Marquis Macaw",
        "Emperor Echidna",
        "Lady Lemur Licks",
        "Sultan Seahorse",
        "Colonel Capybara",
        "Czar Cobra",
        "Princess Platypus",
        "Viscount Vulture"
    ]);
}

function getRandomAction() {
    return randomFromArray([
        "Making",
        "Crafting",
        "Brewing",
    ]);
}

function getRandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}