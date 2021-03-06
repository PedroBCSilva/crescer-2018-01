package br.com.cwi.redesocial.dominio.repository;

import br.com.cwi.redesocial.dominio.Post;
import br.com.cwi.redesocial.dominio.Usuario;
import br.com.cwi.redesocial.dominio.VisibilidadePost;
import org.springframework.data.repository.Repository;

import java.util.List;
import java.util.Optional;

public interface IPostRepository extends Repository<Post,Long> {
    void save(Post post);

    Optional<Post> findById(Long id);

    List<Post> findByCriadorInAndVisibilidade(List<Usuario> criador, VisibilidadePost visibilidade);

    Optional<Post> findByIdAndVisibilidade(Long id,VisibilidadePost visibilidade);
}
