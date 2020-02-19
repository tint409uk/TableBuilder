# TableBuilder
 A demo code to to build table with different type of columns
 This shows how multiple design patterns help to solve the issue:
 - Strategy Pattern: render different output with different types of column.
 - Bridge Pattern: decouple rendering cell task from the table to columns (so we can have same/different column implementation for different types of table).