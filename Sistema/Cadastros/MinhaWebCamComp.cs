using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Cadastros
{
    public partial class MinhaWebCamComp : UserControl, IDisposable
    {
        // Altura e largura da imagem gerada pela WebCam
        private int m_Width = 500;
        private int m_Height = 500;

        //Handle da janela de controle da webcam.
        private int mCapHwnd;

        //Flag para verificar se webcam foi parada.
        private bool bStopped = true;


        //Abaixo temos todas as chamadas das APIs do Sistema Operacional Windows
        //Essas chamadas fazem a interface do nosso controle com a WebCam e e com o SO.
        #region API Declarations

        //Esta chamada é uma das mais importantes e é vital para o funcionamento do SO.
        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        //Esta API cria a instancia da webcam para que possamos acessa-la.
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

        //Esta API abre a área de transferência para que possamos buscar os dados da webcam.
        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        //Esta API limpa a área de transferência.
        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();

        //Esta API fecha a área de transferência após utilização.
        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();

        //Esta API recupera os dados da área de transferência para utilização.
        [DllImport("user32.dll")]
        extern static IntPtr GetClipboardData(uint uFormat);

        #endregion

        #region API Constants

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GET_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        #endregion



        public MinhaWebCamComp()
        {
            InitializeComponent();
        }

        //Para garantir que ao sair a webcam será finalizada.
        ~MinhaWebCamComp()
        {
            this.Stop();
        }

        #region Start and Stop Capture Functions

        /// <summary>
        /// Ajusta o tamanho da imagem da WebCam com o tamanho da tela.
        /// </summary>
        private void ImageSize()
        {
            m_Width = ImgWebCam.Size.Width;
            m_Height = ImgWebCam.Size.Height;
        }

        /// <summary>
        /// Iniciar a captura de telas da Webcam.
        /// </summary>
        public void Start()
        {
            try
            {
                //Ajusta o tamanho da imagem.
                ImageSize();

                // Por segurança, chamamos o método stop so para garantirmos que não estamos rodando o código.
                this.Stop();

                // Criamos a janela de captura usando a API "capCreateCaptureWindowA"
                mCapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, m_Width, m_Height, this.Handle.ToInt32(), 0);

                // Liberamos recurso ao sistema operacional.
                Application.DoEvents();

                //Enviamos a mensagem através do SO para conectar com o driver da WebCam.
                SendMessage(mCapHwnd, WM_CAP_CONNECT, 0, 0);

                // Ajustamos o intervalo de captura da webcam.
                // Podemos aqui criar uma propriedade do componente para 
                // alterarmos o tempo. Lembrando que quanto maior o tempo 
                // maior o atraso entre o capturado e o exibido.
                this.tmrRefrashFrame.Interval = 1;
                this.tmrRefrashFrame.Enabled = true;
                bStopped = false;
                this.tmrRefrashFrame.Start();
            }
            catch (Exception excep)
            {
                MessageBox.Show("Ocorreu um erro .\r\n\n" + excep.Message);
                this.Stop();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            try
            {
                // stop the timer
                bStopped = true;
                this.tmrRefrashFrame.Stop();

                // Liberamos recurso ao sistema operacional.
                Application.DoEvents();

                //Envia mensagem ao SO para desconectar a Webcam.
                SendMessage(mCapHwnd, WM_CAP_DISCONNECT, 0, 0);

                //Fecha a área de transferência.
                CloseClipboard();
                //Dispose();
            }

            catch (Exception excep)
            { // Não dispara nenhum erro.
            }

        }


        #endregion


        #region Codigo de Captura de video.

        /// <summary>
        /// Captura os frames
        /// </summary>
        private void tmrRefrashFrame_Tick(object sender, System.EventArgs e)
        {
            try
            {
                // Pausa o temporizador
                this.tmrRefrashFrame.Stop();

                //Ajusta o tamanho da imagem.
                ImageSize();

                // Envia ao SO a mensagem para capturar o próximo frame.
                SendMessage(mCapHwnd, WM_CAP_GET_FRAME, 0, 0);

                // copia o frame capturado para a área de transferência.
                SendMessage(mCapHwnd, WM_CAP_COPY, 0, 0);

                //Abre a área de transferência.
               OpenClipboard(mCapHwnd);

                //Busca os dados da área de transferÊncia, colocando os dados em 
                //uma estrutura de ponteiro.
               IntPtr img = GetClipboardData(2);

                //Fecha a área de transferÊncia.
                CloseClipboard();

                //Criamos aqui um objeto do tipo Bitmap.
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m_Width, m_Height);

                //Criamos um objeto gráfico para manipular nossa imagem.
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                {
                    //Ajustamos algumas propriedades do nosso objeto gráfico.
                    //No caso abaixo, estou tentanto otimizar ao máximo a velocidade.
                    //Mas também a possível ajustar para a qualidade da imagem.
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

                    //Pegamos a imagem que está na estrutura do ponteiro que buscamos da 
                    //área de transferÊncia e carregamos dentro do nosso bitmap.
                    g.DrawImage(Image.FromHbitmap(img), 0, 0, m_Width, m_Height);
                }
                //Exibimos o frame da Webcam no controle que adicionamos no formulário
                //o frame foi salvo na variável do tipo Bitmap
                //e será exibido no controle System.Windows.Forms.PictureBox abaixo.
                ImgWebCam.Image = bmp;

                //fazemos um refresh na imagem.
                ImgWebCam.Refresh();

                // Liberamos recurso ao sistema operacional.
                Application.DoEvents();

                if (!bStopped)
                    this.tmrRefrashFrame.Start();
            }
            catch (Exception excep)
            {
                IDataObject tempObj = Clipboard.GetDataObject();

                Image tempimg = (System.Drawing.Bitmap)tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);
                MessageBox.Show("Ocorreu um erro na exibição da WebCam. Verifique se está tudo conectado.\r\n\n" + excep.Message);
                this.Stop(); // stop the process
            }
        }
        #endregion
         void IDisposable.Dispose() 
        {
            this.Dispose();

        }
    }

}