import { v4 as uuidv4 } from 'uuid';

export interface IBasketItem {
  id: number;
  productName: string;
  quantity: number;
  pictureUrl: string;
  brand: string;
  type: string;
  price: number;
}

export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export class Basket implements IBasket {
  id = uuidv4();
  items: IBasketItem[] = new Array<IBasketItem>();

}

export interface IBasketTotals {
  shipping: number;
  subtotal: number;
  total: number;
}
