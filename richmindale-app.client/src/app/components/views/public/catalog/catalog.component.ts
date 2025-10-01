import { Component } from '@angular/core';
import { environment } from '../../../../../environment/environment'; 

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html'
})
export class CatalogComponent {
  src = environment.ROOT_URL + 'img/Richmindale-Catalog-2502.pdf';
}
