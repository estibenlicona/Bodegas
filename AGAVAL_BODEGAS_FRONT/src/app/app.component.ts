import { Component } from '@angular/core';

export interface Section {
  src: string;
  title: string;
  icon: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';

  itemsMenu: Section[] = [
    {
      src: 'bodegas',
      title: 'Listado',
      icon: 'format_list_bulleted'
    },
    {
      src: 'bodega',
      title: 'Crear',
      icon: 'post_add'
    }
  ];

}
