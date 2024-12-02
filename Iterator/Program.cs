Library l = new Library();
l.AddBook(new Book("1984", "1984", 1984));
l.AddBook(new Book("1985", "1985", 1985));
Iterator I = l.GetIterator();
I.Next();
Console.WriteLine(I.Current().year);
I.Next();
Console.WriteLine(I.Current().year);
I.Next();
Console.WriteLine(I.Current().year);
I.Reset();
I.Next();
Console.WriteLine(I.Current().year);




class Book
{
    public string title, author;
    public int year;
    public Book(string title, string author, int year)
    {
        this.title = title;
        this.author = author;
        this.year = year;
    }
}


class Iterator
{
    private protected Library lib;
    private protected int current = -1;
    public Iterator(Library lib) { this.lib = lib; }
    public void Reset() { current = -1; }
    public void Next() { current += 1; if (current >= lib.GetLength()) current = 0; }
    public Book Current() { return lib.GetBook(current); }
}


class Library
{
    private protected List<Book> books = new List<Book>();
    public void AddBook(Book book) {  books.Add(book); }
    public Iterator GetIterator() { return new Iterator(this); }
    public Book GetBook(int index) { return books[index]; }
    public int GetLength() { return books.Count(); }
}