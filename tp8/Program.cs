// See https://aka.ms/new-console-template for more information
using System.IO;
Console.WriteLine("Ingrese la ruta a la carpeta que quiere leer: ");
string?  ruta = Console.ReadLine();

if(Directory.Exists(ruta)){
    List<string> ListaCarpetas = Directory.GetDirectories(ruta).ToList();

    foreach (string item in ListaCarpetas)
    {
        Console.WriteLine(item);
    }
    string archivo = ruta + @"\index.csv";
    FileStream FS;
    if(!File.Exists(archivo)){
        FS=File.Create(archivo);
        FS.Close();
    }
    using(StreamWriter lectura = new StreamWriter(archivo)) //con el using ya no dependo del close
    {   
        lectura.Write("IDENTIFICADOR"+";"+"TITULO"+";"+"EXTENSION"+"\n");
        int id=1;
        foreach (string carpeta in ListaCarpetas)
        {
            lectura.Write(id +";"+new DirectoryInfo(carpeta).Name + ";" + "\n");
            id++;
        }
        foreach (string archivos in Directory.GetFiles(ruta))
        {
            lectura.Write(id +";"+ Path.GetFileNameWithoutExtension(archivos) + ";" + Path.GetExtension(archivos) + ";" + "\n");
            id++;
        }
    } 



    // StreamWriter lectura = new StreamWriter(archivo);

    // lectura.Write(ListaCarpetas);
    // lectura.Close(); aca tengo que usar close
}
