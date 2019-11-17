import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  // set model to empty object
  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  login() {
    console.log(this.model);
  }

}
