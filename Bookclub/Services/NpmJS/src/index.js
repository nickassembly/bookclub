﻿import { isbn } from 'node-isbn';

window.getBookInfo = function (isbn) {

   // var isbn = require('node-isbn');

    isbn.resolve("0735619670", function (err, book) {
        if (err) {
            console.log('Book not found', err);
        } else {
            console.log('Book found %j', book);
        }
    });

    console.log("js method hit");
}

// Possibly get data from Isbn library and return via this type of method? 
//window.ReturnData = (bookIsbn) => {
//    var isbn = require('node-isbn');

//    isbn.resolve(bookIsbn, function (err, book) {
//        if (err) {
//            console.log('Book not found', err);
//        } else {
//            console.log('Book found %j', book);
//            return book;
//        }
//    });
//};
