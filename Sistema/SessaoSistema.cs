using System.Collections.Generic;
public static class SessaoSistema
{
    //usuario
    private static string _usuarioId;
    private static string _nomeUsuario;
    private static string _perfil;
    private static string _caixa;
    private static int _caixaId;
    private static bool _desbloqueado;

    private static List<string> list = new List<string>();
    public static List<string> List
    {
        get { return list; }
        set { list = value; }
    }
    private static List<string> listcargo = new List<string>();
    //get e set
    public static string UsuarioId
    {
        get { return SessaoSistema._usuarioId; }
        set { SessaoSistema._usuarioId = value; }
    }
    public static string NomeUsuario
    {
        get { return SessaoSistema._nomeUsuario; }
        set { SessaoSistema._nomeUsuario = value; }
    }
    public static string perfil
    {
        get { return SessaoSistema._perfil; }
        set { SessaoSistema._perfil = value; }
    }
    public static string caixa
    {
        get { return SessaoSistema._caixa; }
        set { SessaoSistema._caixa = value; }
    }
    public static int caixaId
    {
        get { return SessaoSistema._caixaId; }
        set { SessaoSistema._caixaId = value; }
    }
    public static bool Desbloqueado
    {
        get { return SessaoSistema._desbloqueado; }
        set { SessaoSistema._desbloqueado = value; }
    }
}
    