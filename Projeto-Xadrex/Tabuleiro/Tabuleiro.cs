namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;//Matriz de pecas privadas

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];// inicia a matriz
        }

        public Peca peca(int linha, int coluna)// como a matriz pecas é privada é feito um metodo para que retorne a matriz.
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)//recebe uma posiçao pos
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);// caso a posicao nao valide o metodo corta e lanca uma exception
            return peca(pos) != null;// retorna as posicoes diferentes de nullas caso valide
        }
        public void colocarPeca(Peca p, Posicao pos)// coloca a peça no tabuleiro
        {
            if (existePeca(pos))//se existir peca na posicao
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao=pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha<0|| pos.linha>=linhas|| pos.coluna<0|| pos.coluna>=colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))// se não for valida  
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }
    }
}
