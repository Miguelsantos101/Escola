import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

constructor() { }

salvaUsuarioLogado (user: any) {
  sessionStorage.setItem('cpflogado', user.cpf);
}

usuarioLogado(): any {
  return sessionStorage.getItem('cpflogado');
}

limpaUsuario() {
  sessionStorage.clear();
}

autenticado() {
  if(this.usuarioLogado() === null)
    return false;
  return true;
}
}
