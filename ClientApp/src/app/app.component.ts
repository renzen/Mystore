import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Item } from './models/item.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'mystore';

  constructor(private repo: Repository) {}

  // 1
  // get item(): Item {
  //   return this.repo.itemData;
  // }

  // 2
  get items(): Item[] {
    return this.repo.itemsData;
  }

ngOnInit() {

}


}
