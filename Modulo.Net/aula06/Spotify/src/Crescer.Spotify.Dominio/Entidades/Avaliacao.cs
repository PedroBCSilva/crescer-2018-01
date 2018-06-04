namespace Crescer.Spotify.Dominio.Entidades
{
    public class Avaliacao
    {
        public Avaliacao() { }

        public Avaliacao(Musica idMusica, Usuario Usuario, int nota)
        {
            this.Musica = Musica;
            this.Usuario = Usuario;
            this.Nota = nota;

        }
        public int Id { get; set; }
        
        public Musica Musica { get; private set; }

        public Usuario Usuario { get; private set; }

        public int Nota { get; private set; }

    }
}