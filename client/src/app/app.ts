import { NgClass } from '@angular/common';
import { Component, inject, OnInit, Signal, signal } from '@angular/core';
import { Nav } from "../layout/nav/nav";

import { Router, RouterOutlet } from '@angular/router';
import { ConfiromDialog } from "../shared/confirom-dialog/confirom-dialog";

@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet, ConfiromDialog],
  templateUrl:'./app.html',
  styleUrl: './app.css'
})
export class App  {

protected router = inject(Router);
 




}
