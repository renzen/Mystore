import { Item } from '../models/item.model';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';



@Injectable()
export class Repository {



  constructor(private http: HttpClient) {
    this.getAllItems();
    // console.log('Resulta' + getAllItems());
  }
  private baseUrl = 'http://localhost:5002';
  private itemUrl = this.baseUrl + '/api/items';

  // itemData: Item;
  itemsData: Item[];

  getAllItems() {
    // this.http.get<Item>(this.baseUrl + '/api/items')
    //   .subscribe(result => {
    //     this.itemData = result;

    //   },
    //     error => console.error(error));

    this.getItems(true);
  }

  // 1
  // getItem(id: number) {
  //   this.http.get(this.itemUrl + '/' + id)
  //     .subscribe( response => { this.itemData = response; });
  // }

  // 2
  getItems(related = false){
    this.http.get<Item[]>(this.itemUrl + '?related=' + related)
    .subscribe(response => this.itemsData = response);
  }

}

