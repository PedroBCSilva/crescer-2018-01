package br.com.cwi.redesocial.service.cliente;

import br.com.cwi.redesocial.dominio.Usuario;
import br.com.cwi.redesocial.dominio.repository.IUsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.Objects;

@Repository
public class CadastraUsuarioService {
    @Autowired
    private IUsuarioRepository usuarioRepository;

    @Autowired
    private BuscaUsuarioPorEmailService buscaUsuarioPorEmailService;

    public void cadastra(Usuario usuario){

        if(Objects.isNull(usuario)){
            throw new IllegalArgumentException("Usuario nulo");
        }

        if(Objects.isNull(usuario.getNome())||usuario.getNome().length()==0){
            throw new IllegalArgumentException("Nome invalido");
        }

        if(Objects.isNull(usuario.getEmail())||usuario.getEmail().length()==0){
            throw new IllegalArgumentException("Email nulo");
        }

        if(Objects.isNull(usuario.getSenha())||usuario.getSenha().length()==0){
            throw new IllegalArgumentException("Senha nulo");
        }

        if(Objects.isNull(usuario.getDataDeNascimento())){
            throw new IllegalArgumentException("Data nascimento nula");
        }

        Usuario usuarioCadastrado = buscaUsuarioPorEmailService.buscar(usuario.getEmail());

        if(usuarioCadastrado==null){


            usuarioRepository.save(usuario);
        }else{
            throw  new IllegalArgumentException("Esse email já possui uma conta");
        }
    }
}
