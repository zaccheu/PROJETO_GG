import { MyService } from './../../services/services';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})

export class TableComponent implements OnInit {
  data: any;

  constructor(private myService: MyService) {}

  ngOnInit() {
      this.myService.getData().subscribe(data => {
          this.data = data;
      });
  }
}
