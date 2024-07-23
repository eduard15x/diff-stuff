import { CurrentUserInterface } from 'src/app/shared/types/currentUser.interface';

// will be used as response for create, update, get
export interface AuthResponseInterface {
  user: CurrentUserInterface;
}
