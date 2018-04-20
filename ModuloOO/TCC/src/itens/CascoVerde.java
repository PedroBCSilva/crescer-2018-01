package itens;

import corredores.Corredor;
import itens.tipos_de_itens.ataque.ItemDeAtaque;

public class CascoVerde implements ItemDeAtaque {

    private int dano;

    public CascoVerde() {
        this.dano = 3;
    }

    @Override
    public void usarAlvo(Corredor corredorQueLancouOItem,Corredor alvo) {
        alvo.recebeDano(this.dano);
    }

}
