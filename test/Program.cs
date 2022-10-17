using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            Editor texteditor = new TextEditor();
            File textfile = texteditor.creator("text");
            textfile.Create();
            textfile.Redact();
            textfile.Save();
            textfile.Close();

            Console.WriteLine("\n-----------------------\n");

            Editor painteditor = new PaintEditor();
            File paintfile = painteditor.creator("Paint");
            paintfile.Create();
            paintfile.Redact();
            paintfile.Save();
            paintfile.Close();


        }
    }

    abstract class File
    {
        public string Name { get; set; }

        public string Path { get; set; }
        
        public void Create()
        {
            Console.WriteLine($"{Name} создан");
        }
        public void Open()
        {
            Console.WriteLine($"{Name} открыт");
        }
        public void Close()
        {
            Console.WriteLine($"{Name} закрыт");
        }
        public void Save()
        {
            Console.WriteLine("Сохранено");
        }
        public void SaveAs(string name)
        {
            Console.WriteLine($"Сохранено как {name}");
        }
        abstract public void Redact();
    }

    class TextFile : File
    {
        
        public TextFile(string n)
        {
            Name = n;
            Path = n + ".txt";
        }
        public override void Redact()
        {
            Console.WriteLine("Текст отредактирован");
        }

    }

    class PaintFile : File
    {

        public PaintFile(string n)
        {
            Name = n;
            Path = n + ".txt";
        }
        public override void Redact()
        {
            Console.WriteLine("Картика отредактирован");
        }

    }  

    abstract class Editor
    {
        abstract public File creator(string name);
        
    }

    class TextEditor : Editor
    {

        public override File creator(string name)
        {
            return new TextFile(name);
        }

    }

    class PaintEditor : Editor
    {
        public override File creator(string name)
        {
            return new PaintFile(name);
        }
    }

}
