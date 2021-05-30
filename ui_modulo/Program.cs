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
                aux = Convert.ToInt32(Console.ReadLine());
                Categoria categoria = new Categoria();
                NCategoria ncategoria = new NCategoria();
                switch (aux)
                {
                    case 1:
                        {
                            string nombre;
                            Console.WriteLine("escriba una descripcion para categoria");
                            nombre = Console.ReadLine();
                            categoria.Nombre = nombre;
                            if (ncategoria.Nuevo(categoria))
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
                            int id_categoria;
                            string descripcionnueva;
                            Console.WriteLine("ingrese el id de la categoria a modificar ");
                            id_categoria = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("ingrese nueva descripcion");
                            descripcionnueva = Console.ReadLine();
                            if (ncategoria.Editar(id_categoria, descripcionnueva))
                            {
                                Console.WriteLine("se edito la categoria con id {0}",id_categoria);
                            }
                            else
                            {
                                Console.WriteLine("no se pudo editar categoria con id {0}",id_categoria);
                            }

                            break;
                        }
                        default:
                        Console.WriteLine("opcion incorrecta vuelva a intentar ");
                        break;
                }
            } while (aux != 0);
            Console.ReadKey();

        }
    }
}
    