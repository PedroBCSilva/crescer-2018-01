package jogo.ordenacoes;

import jogo.Item;

public class EstrategiaDeOrdenacaoPeso extends EstrategiaDeOrdenacao {
    @Override
    protected boolean compara(Item a, Item b) {
        return a.getPeso()>b.getPeso();
    }
}
