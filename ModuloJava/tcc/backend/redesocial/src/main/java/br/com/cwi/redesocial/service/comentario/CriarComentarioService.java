package br.com.cwi.redesocial.service.comentario;

import br.com.cwi.redesocial.dominio.Comentario;
import br.com.cwi.redesocial.dominio.Post;
import br.com.cwi.redesocial.dominio.Usuario;
import br.com.cwi.redesocial.dominio.repository.IComentarioRepository;
import br.com.cwi.redesocial.service.usuario.BuscaUsuarioPorEmailService;
import br.com.cwi.redesocial.service.post.BuscarPostPorIdService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Objects;

@Service
public class CriarComentarioService {

    @Autowired
    private IComentarioRepository comentarioRepository;

    @Autowired
    private BuscaUsuarioPorEmailService buscaUsuarioPorEmailService;

    @Autowired
    private BuscarPostPorIdService buscarPostPorIdService;

    @Transactional
    public void criar(String email, Long idPost,Comentario comentario){
        Usuario usuarioCarregado = buscaUsuarioPorEmailService.buscar(email);
        Post post = buscarPostPorIdService.buscar(idPost);

        if(Objects.isNull(usuarioCarregado)){
            throw new IllegalArgumentException("Sem Usuario com esse email");
        }
        if(Objects.isNull(post)){
            throw new IllegalArgumentException("Sem post com esse id");
        }
        if(Objects.isNull(comentario)){
            throw new IllegalArgumentException("Comentario nulo");
        }
        if(Objects.isNull(comentario.getTexto())||comentario.getTexto().length()==0){
            throw new IllegalArgumentException("Texto do comentario está nulo ou vazio");
        }

        comentario.setUsuario(usuarioCarregado);
        comentario.setPost(post);

        comentarioRepository.save(comentario);

    }
}
