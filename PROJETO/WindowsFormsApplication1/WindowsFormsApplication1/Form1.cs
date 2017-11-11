 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int texTelhado;
        int texPorta;
        int texPiso;
        int texBalcao;
        int texGrama;
        int lateral = 0;
        Vector3d dir = new Vector3d(0, -450, 120);        //direção da câmera
        Vector3d pos = new Vector3d(0, -550, 120);     //posição da câmera
        float camera_rotation = 0;                     //rotação no eixo Z


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //limpa os buffers
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade


            //                 Matrix4 lookat = Matrix4.LookAt(lateral, -500.0f, 1.5f,    
            //                                              1.5f, 5.0f, 1.5f,
            //                                           0.0f, 0.0f, 1.0f);
            Matrix4d lookat = Matrix4d.LookAt(pos.X, pos.Y, pos.Z, dir.X, dir.Y, dir.Z, 0, 0, 1);

            //aplica a transformacao na matriz de rotacao
            GL.LoadMatrix(ref lookat);
            //GL.Rotate(camera_rotation, 0, 0, 1);

            GL.Enable(EnableCap.DepthTest);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texGrama);
            //GRAMADO
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, -100, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 5, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(920, 5, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(920, -100, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Texture2D); 
            GL.BindTexture(TextureTarget.Texture2D, texGrama);
            //GRAMADO 2
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(770, -50, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(770, 450, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(920, 450, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(920, -50, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texGrama);
            //GRAMADO 3
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, 670, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 450, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(110, 450, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(110, 670, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPiso);
            //PISO
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, 0, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 450, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(770, 450, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(770, 0, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPiso);
            //PISO 2
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(110, 450, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(110, 670, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(920, 670, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(920, 450, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Color3(Color.PapayaWhip);
            //LATERAL DIREITA
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(380, 0.0, 190);
            GL.Vertex3(380, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 190);

            GL.Vertex3(440, 0.0, 190);
            GL.Vertex3(440, 0.0, 0.0);
            GL.Vertex3(520, 0.0, 0.0);
            GL.Vertex3(520, 0.0, 190);

            GL.Vertex3(650, 0.0, 190);
            GL.Vertex3(650, 0.0, 0.0);
            GL.Vertex3(670, 0.0, 0.0);
            GL.Vertex3(670, 0.0, 190);

            GL.Vertex3(380, 0.0, 100);
            GL.Vertex3(380, 0.0, 0.0);
            GL.Vertex3(520, 0.0, 0.0);
            GL.Vertex3(520, 0.0, 100);

            GL.Vertex3(100, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 0.0);
            GL.Vertex3(660, 0.0, 0.0);
            GL.Vertex3(660, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 190.0);
            GL.Vertex3(100, 0.0, 140.0);
            GL.Vertex3(660, 0.0, 140.0);
            GL.Vertex3(660, 0.0, 190.0);

            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 190);
            GL.Vertex3(100.0, 0.0, 190.0);
            GL.Vertex3(100.0, 0.0, 0.0);

            GL.End();
            //JANELA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(100, 0, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(250, 0, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(250, 0, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(100, 0, 60);
            GL.End();

            //JANELA QUARTO PEDRO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(20, 450, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(90, 450, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(90, 450, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(20, 450, 60);
            GL.End();

            //JANELA QUARTO MATHEUS
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(110, 600, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(110, 500, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(110, 500, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(110, 600, 60);
            GL.End();

            //JANELA COZINHA 2
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(770, 400, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(770, 300, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(770, 300, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(770, 400, 60);
            GL.End();

            //JANELA SALA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(520, 0, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(650, 0, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(650, 0, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(520, 0, 60);
            GL.End();

            //JANELA COZINHA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(570, 670, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(700, 670, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(700, 670, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(570, 670, 60);
            GL.End();

            //JANELA BANHEIRO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(380, 0, 170);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(440, 0, 170);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(440, 0, 100);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(380, 0, 100);
            GL.End();

            //JANELA BANHEIRO DE FORA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(815, 670, 170);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(875, 670, 170);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(875, 670, 100);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(815, 670, 100);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //FRENTE
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 250, 0);
            GL.Vertex3(0, 250, 240);
            GL.Vertex3(0, 125, 215);
            GL.Vertex3(0, 0, 190);
            GL.End();

            //FUNDO COM TELHADO
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 0, 0);
            GL.Vertex3(770, 180, 0);
            GL.Vertex3(770, 180, 235);
            GL.Vertex3(770, 125, 220);
            GL.Vertex3(770, 0, 190);
            GL.End();

            //FUNDO COM TELHADO 2
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 0, 190);
            GL.Vertex3(770, 350, 190);
            GL.Vertex3(770, 350, 286);
            GL.Vertex3(770, 125, 220);
            GL.Vertex3(770, 0, 190);
            GL.End();

            //FUNDO COM TELHADO BANHEIRO DE FORA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(920, 550, 226);
            GL.Vertex3(920, 670, 190);
            GL.Vertex3(920, 670, 190);
            GL.Vertex3(920, 450, 190);
            GL.Vertex3(920, 450, 190);
            GL.End();

            //FUNDO COM TELHADO 3
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 350, 190);
            GL.Vertex3(770, 665, 190);
            GL.Vertex3(770, 665, 190);
            GL.Vertex3(770, 350, 286);
            GL.Vertex3(770, 350, 350);
            GL.End();

            //PAREDE SALA, COZINHA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 0, 0);
            GL.Vertex3(770, 180, 0);
            GL.Vertex3(770, 180, 190);
            GL.Vertex3(770, 125, 190);
            GL.Vertex3(770, 0, 190);
            GL.End();

            //PAREDE EM CIMA DA PORTA COZINHA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 175, 180);
            GL.Vertex3(770, 250, 180);
            GL.Vertex3(770, 250, 190);
            GL.Vertex3(770, 175, 190);
            GL.Vertex3(770, 175, 190);
            GL.End();

            //PAREDE SALA, COZINHA 2 
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(770, 250, 0);
            GL.Vertex3(770, 670, 0);
            GL.Vertex3(770, 670, 190);
            GL.Vertex3(770, 250, 250);
            GL.Vertex3(770, 250, 200);
            GL.End();

            //PAREDE COZINHA BANHEIRO FORA 
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(920, 450, 0);
            GL.Vertex3(920, 670, 0);
            GL.Vertex3(920, 670, 190);
            GL.Vertex3(920, 450, 190);
            GL.Vertex3(920, 450, 190);
            GL.End();

            //PORTA PEDRO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(390, 250, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(390, 320, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(390, 320, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(390, 250, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA MATHEUS
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(390, 450, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(500, 450, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(500, 450, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(390, 450, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA PAI
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(320, 180, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(320, 250, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(320, 250, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(320, 180, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA CORREDOR, COZINHA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(500, 180, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(500, 250, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(500, 250, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(500, 180, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA COZINHA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(770, 180, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(770, 250, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(770, 250, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(770, 180, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA BANHEIRO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(390, 165, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(500, 165, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(500, 165, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(390, 165, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA SALA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(770, 0, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(660, 0, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(660, 0, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(770, 0, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA BANHEIRO DE FORA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(860, 450, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(790, 450, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(790, 450, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(860, 450, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PAREDE FUNDO
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(320, 0, 0);
            GL.Vertex3(320, 250, 0);
            GL.Vertex3(320, 250, 190);
            GL.Vertex3(320, 125, 190);
            GL.Vertex3(320, 0, 190);
            GL.End();

            //PAREDE PEDRO (QUARTO)
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(0, 250, 0);
            GL.Vertex3(0, 450, 0);
            GL.Vertex3(0, 450, 190);
            GL.Vertex3(0, 450, 190);
            GL.Vertex3(0, 250, 240);
            GL.End();

            //PAREDE MATHEUS (QUARTO)
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon); 
            GL.Vertex3(110, 670, 0);
            GL.Vertex3(110, 450, 0);
            GL.Vertex3(110, 450, 190);
            GL.Vertex3(110, 450, 250);
            GL.Vertex3(110, 670, 190);
            GL.End();

            //PAREDE MATHEUS (QUARTO) 2
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(110, 450, 190);
            GL.Vertex3(110, 450, 250);
            GL.Vertex3(110, 350, 276);
            GL.Vertex3(110, 250, 250);
            GL.Vertex3(110, 450, 190);
            GL.End();

            //PAREDE PEDRO (CORREDOR,QUARTO)
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(390, 250, 0);
            GL.Vertex3(390, 450, 0);
            GL.Vertex3(390, 450, 190);
            GL.Vertex3(390, 450, 190);
            GL.Vertex3(390, 250, 190);
            GL.End();

            //PAREDE MATHEUS (QUARTO,CORREDOR E COZINHA)
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(500, 670, 0);
            GL.Vertex3(500, 0, 0);
            GL.Vertex3(500, 0, 190);
            GL.Vertex3(500, 0, 190);
            GL.Vertex3(500, 670, 190);
            GL.End();

            //PAREDE QUARTO PAI, PEDRO
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(390, 250.0, 190); 
            GL.Vertex3(390, 250.0, 0.0);
            GL.Vertex3(0.0, 250.0, 0.0);
            GL.Vertex3(0.0, 250.0, 190);
            GL.End();

            //LATERAL BANHEIRO
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(390, 165.0, 190); 
            GL.Vertex3(390, 165.0, 0.0); 
            GL.Vertex3(320.0, 165.0, 0.0); 
            GL.Vertex3(320.0, 165.0, 190); 
            GL.End();

            //PAREDE EMCIMA DA PORTA DO BANHEIRO
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(500, 165.0, 190);
            GL.Vertex3(500, 165.0, 180.0);
            GL.Vertex3(390.0, 165.0, 180.0);
            GL.Vertex3(390.0, 165.0, 190);
            GL.End();

            //PAREDE EMCIMA DA PORTA DA SALA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(770, 0.0, 190);
            GL.Vertex3(770, 0.0, 180.0);
            GL.Vertex3(660.0, 0.0, 180.0);
            GL.Vertex3(660.0, 0.0, 190);
            GL.End();

            //PAREDE SALA COZINHA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(660, 175.0, 190);
            GL.Vertex3(660, 175.0, 0.0);
            GL.Vertex3(500.0, 175.0, 0.0);
            GL.Vertex3(500.0, 175.0, 190);
            GL.End();

            //BALCÃO COZINHA
            GL.Color3(Color.PaleGoldenrod);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(660, 550.0, 80);
            GL.Vertex3(660, 550.0, 0.0);
            GL.Vertex3(500.0, 550.0, 0.0);
            GL.Vertex3(500.0, 550.0, 80);
            GL.End();

            GL.Enable(EnableCap.Texture2D); //habilita o uso de texturas
            GL.BindTexture(TextureTarget.Texture2D, texBalcao);
            //BALCÃO
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(500, 530, 80);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(500, 570, 80);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(670, 570, 80);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(670, 530, 80);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PAREDE EMCIMA DA PORTA DO QUARTO MATHEUS
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(500, 450.0, 190);
            GL.Vertex3(500, 450.0, 180.0);
            GL.Vertex3(390.0, 450.0, 180.0);
            GL.Vertex3(390.0, 450.0, 190);
            GL.End();

            //PAREDE QUARTO PEDRO MATHEUS
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(390, 450.0, 190);
            GL.Vertex3(390, 450.0, 0.0);
            GL.Vertex3(0.0, 450.0, 0.0);
            GL.Vertex3(0.0, 450.0, 190);
            GL.End();

            //PAREDE QUARTO MATHEUS
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(770, 670.0, 190);
            GL.Vertex3(770, 670.0, 0.0);
            GL.Vertex3(110.0, 670.0, 0.0);
            GL.Vertex3(110.0, 670.0, 190);
            GL.End();

            //PAREDE BANHEIRO DE FORA
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(790, 450.0, 190);
            GL.Vertex3(790, 450.0, 0.0);
            GL.Vertex3(770.0, 450.0, 0.0);
            GL.Vertex3(770.0, 450.0, 190);
            GL.End();
            
            //PAREDE BANHEIRO DE FORA 2
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(920, 450.0, 190);
            GL.Vertex3(920, 450.0, 0.0);
            GL.Vertex3(860.0, 450.0, 0.0);
            GL.Vertex3(860.0, 450.0, 190);
            GL.End();
            
            //PAREDE BANHEIRO DE FORA 3
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(920, 670.0, 190);
            GL.Vertex3(920, 670.0, 0.0);
            GL.Vertex3(875.0, 670.0, 0.0);
            GL.Vertex3(875.0, 670.0, 190);
            GL.End();

            //PAREDE BANHEIRO DE FORA 4
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(860, 450.0, 190);
            GL.Vertex3(860, 450.0, 180.0);
            GL.Vertex3(790.0, 450.0, 180.0);
            GL.Vertex3(790.0, 450.0, 190);
            GL.End();

            //PAREDE BANHEIRO DE FORA 5
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(875, 670.0, 190);
            GL.Vertex3(875, 670.0, 170.0);
            GL.Vertex3(815.0, 670.0, 170.0);
            GL.Vertex3(815.0, 670.0, 190);
            GL.End();

            //PAREDE BANHEIRO DE FORA 6
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(875, 670.0, 100);
            GL.Vertex3(875, 670.0, 0.0);
            GL.Vertex3(815.0, 670.0, 0.0);
            GL.Vertex3(815.0, 670.0, 100);
            GL.End();

            //PAREDE BANHEIRO DE FORA 7
            GL.Color3(Color.PapayaWhip);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(815, 670.0, 190);
            GL.Vertex3(815, 670.0, 0.0);
            GL.Vertex3(770.0, 670.0, 0.0);
            GL.Vertex3(770.0, 670.0, 190);
            GL.End();
            
            //TELHADO DIREITA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(65, -40, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(65, 350, 290);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(810, 350, 290);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(810, -40, 184);
            GL.End();

            //TELHADO DIREITA 2
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-40, -40, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-40, 250, 248);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(80, 250, 248);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(80, -40, 184);
            GL.End();
            
            //TELHADO DIREITA 3
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(810, 410, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(810, 550, 228);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(960, 550, 228);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(960, 410, 184);
            GL.End();
            
            //TELHADO DIREITA 4
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(770, 410, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(770, 545, 228);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(820, 545, 228);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(820, 410, 184);
            GL.End();

            //TELHADO ESQUERDA
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-40, 490, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-40, 250, 250);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(110, 250, 250);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(110, 490, 184);
            GL.End();
            
            //TELHADO ESQUERDA 2
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(70, 710, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(70, 350, 290);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(810, 350, 290);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(810, 710, 184);
            GL.End();

            //TELHADO ESQUERDA 3
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(810, 710, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(810, 550, 228);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(960, 550, 228);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(960, 710, 184);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
            //BEIRAL
            GL.Color3(Color.SaddleBrown);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(70, -40, 174);
            GL.Vertex3(70, 350, 280);
            GL.Vertex3(70, 350, 290);
            GL.Vertex3(70, -40, 184);

            GL.Vertex3(-40, 490, 174);
            GL.Vertex3(-40, 490, 184);
            GL.Vertex3(-40, 250, 248);
            GL.Vertex3(-40, 250, 238);

            GL.Vertex3(-40, 250, 238);
            GL.Vertex3(-40, 250, 248);
            GL.Vertex3(-40, -40, 184);
            GL.Vertex3(-40, -40, 174);

            GL.Vertex3(70, 710, 174);
            GL.Vertex3(70, 710, 184);
            GL.Vertex3(70, 350, 290);
            GL.Vertex3(70, 350, 280);

            GL.Vertex3(810, -40, 174);
            GL.Vertex3(810, 350, 280);
            GL.Vertex3(810, 350, 290);
            GL.Vertex3(810, -40, 184);

            GL.Vertex3(960, 410, 174);
            GL.Vertex3(960, 550, 218);
            GL.Vertex3(960, 550, 228);
            GL.Vertex3(960, 410, 184);

            GL.Vertex3(810, 710, 174);
            GL.Vertex3(810, 710, 184);
            GL.Vertex3(810, 350, 290);
            GL.Vertex3(810, 350, 280);

            GL.Vertex3(960, 710, 174);
            GL.Vertex3(960, 710, 184);
            GL.Vertex3(960, 550, 228);
            GL.Vertex3(960, 550, 218);

            GL.Vertex3(810, -40, 174);
            GL.Vertex3(810, -40, 184);
            GL.Vertex3(-40, -40, 184);
            GL.Vertex3(-40, -40, 174);

            GL.Vertex3(960, 710, 174);
            GL.Vertex3(960, 710, 184);
            GL.Vertex3(70, 710, 184);
            GL.Vertex3(70, 710, 174);

            GL.Vertex3(960, 410, 174);
            GL.Vertex3(960, 410, 184);
            GL.Vertex3(770, 410, 184);
            GL.Vertex3(770, 410, 174);

            GL.Vertex3(110, 490, 174);
            GL.Vertex3(110, 490, 184);
            GL.Vertex3(-40, 490, 184);
            GL.Vertex3(-40, 490, 174);

            GL.End();

            glControl1.SwapBuffers(); //troca os buffers de frente e de fundo 
            
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);         // definindo a cor de limpeza do fundo da tela
            GL.Enable(EnableCap.Light0);

            texTelhado = LoadTexture("../../textura/telhado.jpg");
            texPorta = LoadTexture("../../textura/portajanela.jpg");
            texGrama = LoadTexture("../../textura/grama.jpg");
            texPiso = LoadTexture("../../textura/PISO.jpg");
            texBalcao = LoadTexture("../../textura/Marmore.jpg");
            SetupViewport();                      //configura a janela de pintura
        }

        private void SetupViewport() //configura a janela de projeção 
        {
            int w = glControl1.Width; //largura da janela
            int h = glControl1.Height; //altura da janela

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(1f, w / (float)h, 0.1f, 2000.0f);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Viewport(0, 0, w, h); // usa toda area de pintura da glcontrol
            lateral = w / 2;

        }

        static int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id;//= GL.GenTexture(); 

            GL.GenTextures(1, out id);
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(filename);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return id;
        }
        private void calcula_direcao()
        {
            dir.X = pos.X + (Math.Sin(camera_rotation * Math.PI / 180) * 1000);
            dir.Y = pos.Y + (Math.Cos(camera_rotation * Math.PI / 180) * 1000);
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > lateral)
            {
                camera_rotation += 2;
            }
            if (e.X < lateral)
            {
                camera_rotation -= 2;
            }
            lateral = e.X;
            calcula_direcao();
            glControl1.Invalidate();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            float a = camera_rotation;
            int tipoTecla = 0;
            if (e.KeyCode == Keys.Left)
            {
                a -= 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                a += 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Up)
            { tipoTecla = 1; }
            if (e.KeyCode == Keys.Down)
            {
                a += 180;
                tipoTecla = 1;
            }

            if (e.KeyCode == Keys.D)
            {
                a += 1;
                tipoTecla = 2;
            }
            if (e.KeyCode == Keys.A)
            {
                a -= 1;
                tipoTecla = 2;
            }
            if (tipoTecla == 1)
            {
                if (a < 0) a += 360;
                if (a > 360) a -= 360;
                label2.Text = a.ToString();
                pos.X += (Math.Sin(a * Math.PI / 180) * 10);
                pos.Y += (Math.Cos(a * Math.PI / 180) * 10);
                calcula_direcao();
                glControl1.Invalidate();
            }

            if (tipoTecla == 2)
            {
                camera_rotation = a;
                calcula_direcao();
                glControl1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl1.Width = Form1.ActiveForm.Width - 10;
            glControl1.Height = Form1.ActiveForm.Height - 10;
            SetupViewport();
            glControl1.Invalidate();
        }

    }
}
