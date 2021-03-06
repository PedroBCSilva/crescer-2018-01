package br.com.cwi.redesocial.dominio.repository;

import br.com.cwi.redesocial.dominio.Usuario;
import org.springframework.data.repository.Repository;

import java.util.Optional;

public interface IUsuarioRepository extends Repository<Usuario,Long> {

    void save(Usuario usuario);

    Optional<Usuario> findByEmail(String email);

    Optional<Usuario> findById(Long id);
}
