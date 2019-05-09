import { Item } from '../models/item.model';

export class Rating {
  constructor(
    public ratingId?: number,
    public stars?: string,
    public item?: Item) {}
}
