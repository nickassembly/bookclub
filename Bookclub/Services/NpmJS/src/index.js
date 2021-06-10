

window.getBookInfo = function (bookIsbn) {

    var isbn = require('node-isbn');

    isbn.resolve(bookIsbn, function (err, book) {
        if (err) {
            console.log('Book not found', err);
        } else {
            console.log('Book found %j', book);
        }
    });

    console.log("js method hit");
}
