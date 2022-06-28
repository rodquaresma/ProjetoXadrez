namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];            
        }

        public Peca peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return Peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }        
            Pecas[pos.linha, pos.coluna] = p;
            p.Posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= Linhas || pos.coluna < 0 || pos.coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
