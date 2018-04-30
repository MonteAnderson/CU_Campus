using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CULibrary
{
    public class Bookshelf
    {
        private const float TOP_SHELF_Y_OFFSET = 1.82f;
        private const float MIDDLE_SHELF_Y_OFFSET = 1.285f;
        private const float BOTTOM_SHELF_Y_OFFSET = 0.8f;
        private const float COLUMN_OFFSET = 1.63f;
        private const float BOOK_OFFSET = 0.1475f;

        public enum BookshelfType
        {
            WEST_WALL_LEFT,
            WEST_WALL_RIGHT,
            NORTH_WALL_LEFT,
            NORTH_WALL_RIGHT,
            EAST_WALL_LEFT,
            EAST_WALL_RIGHT
        };

        private float pos_y;
        private Vector3 rotaionVector;

        private float init_book_pos_x;
        private float init_book_pos_z;
        private List<Book> books = new List<Book>();

        public Bookshelf(BookshelfType bookshelfType, float pos_y, List<Book> books)
        {
            this.pos_y = pos_y;
            this.books = books;

            // initialize bookshelf based on type
            switch (bookshelfType)
            {
                case BookshelfType.WEST_WALL_LEFT:
                    this.init_book_pos_x = -9.1f;
                    this.init_book_pos_z = -7.45f;
                    this.rotaionVector = new Vector3(180f, 0f, 270f);
                    break;

                case BookshelfType.WEST_WALL_RIGHT:
                    this.init_book_pos_x = -9.1f;
                    this.init_book_pos_z = 1.225f;
                    this.rotaionVector = new Vector3(180f, 0f, 270f);
                    break;

                case BookshelfType.NORTH_WALL_LEFT:
                    this.init_book_pos_x = -7.45f;
                    this.init_book_pos_z = 9.1f;
                    this.rotaionVector = new Vector3(180f, 90f, 270f);
                    break;

                case BookshelfType.NORTH_WALL_RIGHT:
                    this.init_book_pos_x = 1.225f;
                    this.init_book_pos_z = 9.1f;
                    this.rotaionVector = new Vector3(180f, 90f, 270f);
                    break;

                case BookshelfType.EAST_WALL_LEFT:
                    this.init_book_pos_x = 9.1f;
                    this.init_book_pos_z = 7.55f;
                    this.rotaionVector = new Vector3(180f, 180f, 270f);
                    break;

                case BookshelfType.EAST_WALL_RIGHT:
                    this.init_book_pos_x = 9.1f;
                    this.init_book_pos_z = -1.225f;
                    this.rotaionVector = new Vector3(180f, 180f, 270f);
                    break;
            }

            // place books on bookshelf
            int bookIndex = 0;
            foreach (Book book in books)
            {
                // determine column in bookshelf
                int remainder = -1;

                int columnIndex = -1;
                
                for(int i = Constants.TOTAL_COLUMNS_PER_BOOKSHELF - 1; i >= 0; i--)
                {
                    if(i == 0)
                    {
                        remainder = bookIndex;
                        columnIndex = 0;
                        break;
                    }

                    if(bookIndex >= (i * Constants.TOTAL_BOOKS_PER_COLUMN))
                    {
                        remainder = bookIndex % (i * Constants.TOTAL_BOOKS_PER_COLUMN);
                        columnIndex = i;
                        break;
                    }
                }

                // determine shelf in column
                int rowIndex = -1;

                for (int i = Constants.TOTAL_ROWS_PER_BOOKSHELF - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        rowIndex = (Constants.TOTAL_ROWS_PER_BOOKSHELF-1) - i;
                        break;
                    }

                    if (remainder >= (i * Constants.TOTAL_BOOKS_PER_ROW))
                    {
                        remainder = remainder % (i * Constants.TOTAL_BOOKS_PER_ROW);
                        rowIndex = rowIndex = (Constants.TOTAL_ROWS_PER_BOOKSHELF - 1) - i;
                        break;
                    }
                }

                // determine book position
                float book_x_pos = -1f;
                float book_y_pos = -1f;
                float book_z_pos = -1f;

                // determine y position independent of bookshelf type
                if (rowIndex == 2)
                    book_y_pos = this.pos_y + TOP_SHELF_Y_OFFSET;
                else if (rowIndex == 1)
                    book_y_pos = this.pos_y + MIDDLE_SHELF_Y_OFFSET;
                else
                    book_y_pos = this.pos_y + BOTTOM_SHELF_Y_OFFSET;

                // determine x/z position based on bookshelf type
                switch (bookshelfType)
                {
                    case BookshelfType.WEST_WALL_LEFT:
                        book_x_pos = init_book_pos_x;
                        book_z_pos = init_book_pos_z + (columnIndex * COLUMN_OFFSET) + (remainder * BOOK_OFFSET);
                        break;
                    
                    case BookshelfType.WEST_WALL_RIGHT:
                        book_x_pos = init_book_pos_x;
                        book_z_pos = init_book_pos_z + (columnIndex * COLUMN_OFFSET) + (remainder * BOOK_OFFSET);
                        break;

                    case BookshelfType.NORTH_WALL_LEFT:
                        book_x_pos = init_book_pos_x + (columnIndex * COLUMN_OFFSET) + (remainder * BOOK_OFFSET);
                        book_z_pos = init_book_pos_z;
                        break;

                    case BookshelfType.NORTH_WALL_RIGHT:
                        book_x_pos = init_book_pos_x + (columnIndex * COLUMN_OFFSET) + (remainder * BOOK_OFFSET);
                        book_z_pos = init_book_pos_z;
                        break;

                    case BookshelfType.EAST_WALL_LEFT:
                        book_x_pos = init_book_pos_x;
                        book_z_pos = init_book_pos_z - (columnIndex * COLUMN_OFFSET) - (remainder * BOOK_OFFSET);
                        break;

                    case BookshelfType.EAST_WALL_RIGHT:
                        book_x_pos = init_book_pos_x;
                        book_z_pos = init_book_pos_z - (columnIndex * COLUMN_OFFSET) - (remainder * BOOK_OFFSET);
                        break;
                }

                // initialize book object
                book.initialize(new Vector3(book_x_pos, book_y_pos, book_z_pos), this.rotaionVector);

                bookIndex++;
            }
        }
    }
}