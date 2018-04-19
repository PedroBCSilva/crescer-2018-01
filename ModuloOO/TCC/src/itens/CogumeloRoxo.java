package itens;

import corredores.Corredor;
import tipos_de_itens.uso.ItemDeRecuperacao;

public class CogumeloRoxo implements ItemDeRecuperacao {

    private int cura;

    public CogumeloRoxo() {
        this.cura = 2;
    }

    @Override
    public void usar(Corredor corredor) {
        corredor.recebeCura(this.cura);
    }
}