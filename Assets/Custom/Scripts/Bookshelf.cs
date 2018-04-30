using System;
using System.Collections;
using System.Collections.Generic;

namespace CULibrary
{
    public class Bookshelf
    {
        public enum BookshelfType
        {
            WEST_WALL_LEFT,
            WEST_WALL_RIGHT,
            NORTH_WALL_LEFT,
            NORTH_WALL_RIGHT,
            EAST_WALL_LEFT,
            EAST_WALL_RIGHT
        };

        private double pos_y;
        private BookshelfType bookshelfType;
        private List<Book> books = new List<Book>();

        public Bookshelf(BookshelfType bookshelfType, double pos_y, List<Book> books)
        {
            this.bookshelfType = bookshelfType;
            this.pos_y = pos_y;
            this.books = books;
        }
    }
}