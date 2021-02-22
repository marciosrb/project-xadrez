
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }//associacao com a classe Posicao. - So pode ser alterada por ela mesma e pelas subClasses
        public Cor cor { get; protected set; }//Possui Cores, do tipo enum. - So pode ser alterada por ela mesma e pelas subClasses
        public int qteMovimentos { get; protected set; }//So pode ser alterada por ela mesma e pelas subClasses
        public Tabuleiro tab { get; protected set; }//So pode ser alterada por ela mesma e pelas subClasses

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            qteMovimentos = 0;// iniciada com 0 pois ela ainda nao possui movimentos

        }
        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] movimentosPossiveis();
    }
}
