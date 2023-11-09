using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Grupo_4
{
    public partial class Form1 : Form
    {
        //se crea la cola y pila como array o lista
        static Queue<Pedido> pedidosPendientes = new Queue<Pedido>();
        static Stack<Pedido> pedidosEnCocina = new Stack<Pedido>();
        int totalPedidos = 0;
        int pedidosPreparados = 0;
        int tiempoEspera = 0;
        static DateTime horaPedido;

        //inicial el formulario 
        public Form1()
        {
            InitializeComponent();
            label9.Text = DateTime.Now.ToString("T"); //formato para obtener unicamente la hora sin fecha ("T")
        }

        //boton para incluir los pedidos en la cola
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime horaPedido = DateTime.Now;//fecha para el pedido
            Pedido pedido = new Pedido { codigo = int.Parse(textBox1.Text), cliente  = textBox2.Text, plato = textBox3.Text, bebida = textBox4.Text, hora = horaPedido.ToString("T") };
            pedidosPendientes.Enqueue(pedido);
            
            label7.Text = "El pedido " + ($"Codigo: {pedido.codigo} ha sido ingresado con exito. \n");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


            totalPedidos += 1;

            label9.Text = DateTime.Now.ToString("T");
        }

        //boton para mostrar los pedidos listos
        private void button3_Click(object sender, EventArgs e)
        {
            if (pedidosEnCocina.Count >0)
            {
                DateTime horaPreparado = DateTime.Now;
                Pedido pedido = pedidosEnCocina.Pop();
                label7.Text = "El pedido " + ($"Codigo: {pedido.codigo}, del cliente: {pedido.cliente}, Plato: {pedido.plato}, Bebida: {pedido.bebida}, esta listo para servir a las {horaPreparado.ToString("T")}. \n");
                pedidosPreparados += 1;
             
            }
            else
            {
                label7.Text ="No hay pedidos listos para servir";

            }
  
        }

        //boton para mostrar los pedidos pendientes
        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
            if (pedidosPendientes.Count > 0)
            {
                foreach (var pedido in pedidosPendientes)
                {
                    label7.Text += "-" + ($"Codigo: {pedido.codigo}, Cliente: {pedido.cliente}, Plato: {pedido.plato}, Bebida: {pedido.bebida}, Hora Pedido: {pedido.hora} \n");
                }
            }
            else
            {
                label7.Text = "No hay pedidos pendientes";
            }

        }

        //boton para borrar la data del lado de informacion en el form
        private void button6_Click(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
        }

        //boton para enviar los pedidos a la pila de la cocina para preparar
        private void button5_Click(object sender, EventArgs e)
        {
            if (pedidosPendientes.Count > 0)
            {
                Pedido pedido = pedidosPendientes.Dequeue();
                pedidosEnCocina.Push(pedido);
                label7.Text = "El pedido " + ($"Codigo: {pedido.codigo}, se esta cocinando. \n");

            }
            else
            {
                label7.Text = "No hay pedidos pendientes para cocinar";

            }

        }

        //boton para ver pedidos en cocina
        private void button7_Click(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
            if (pedidosEnCocina.Count > 0)
            {
                foreach (var pedido in pedidosEnCocina)
                {
                    label7.Text += "-" + ($"Codigo: {pedido.codigo}, Cliente: {pedido.cliente}, Plato: {pedido.plato}, Bebida: {pedido.bebida} \n");
                }
            }
            else
            {
                label7.Text = "No hay pedidos en la cocina";
            }

        }

        //boton para revisar estadisticas
        private void button4_Click(object sender, EventArgs e)
        {
            label7.Text = string.Empty;
            label7.Text = ($" Pedidos Realizados: {totalPedidos.ToString()}\n Pedidos Preparados: {pedidosPreparados.ToString()}");

        }

    }
}
