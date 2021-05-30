using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bll_modulo;
using Entidades;

namespace ui_modulo
{
    class Program
    {
        static void Main(string[] args)
        {
            int aux;
            do
            {
                Console.WriteLine("1-agregar \n2-eliminar \n3-editar \n0-salir \n ");
                aux = int.Parse(Console.ReadLine());
                Categoria unCategoria = new Categoria();
                NCategoria ncategoria = new NCategoria();
                switch (aux)
                {
                    case 1:
                        {
                            string nombre;
                            Console.WriteLine("escriba una descripcion para categoria");
                            nombre = Console.ReadLine();
                            unCategoria.Nombre = nombre;
                            if (ncategoria.Nuevo(unCategoria))
                            {
                                Console.WriteLine("se agrego una nueva categoria");
                            }
                            else
                            {
                                Console.WriteLine("no se pudo agregar categoria");
                            }
                            break;
                        }
                    case 2:
                        {
                            int id;
                            Console.WriteLine("ingrese el id de la categoria a eliminar ");
                            id = Convert.ToInt32(Console.ReadLine());
                            if (ncategoria.Eliminar(id))
                            {
                                Console.WriteLine("categoria eliminada con exito");
                            }
                            else
                            {
                                Console.WriteLine("no se pudo eliminar ");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ingrese el id de la categoria a modificar ");
                            unCategoria.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("ingrese nueva descripcion");
                            unCategoria.Nombre = Console.ReadLine();
                            if (ncategoria.Editar(unCategoria))
                            {
                                Console.WriteLine("se edito la categoria con id {0}",unCategoria.ID);
                            }
                            else
                            {
                                Console.WriteLine("no se pudo editar categoria con id {0}",unCategoria.ID);
                            }

                            break;
                        }
                        default:
                        if(aux != 0) Console.WriteLine("opcion incorrecta vuelva a intentar ");
                        break;
                }
            } while (aux != 0);
        }
    }
}
    