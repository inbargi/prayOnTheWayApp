import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ManagerService } from 'src/app/shared/services/manager.service';

@Component({
  selector: 'app-menu-manager',
  templateUrl: './menu-manager.component.html',
  styleUrls: ['./menu-manager.component.css']
})
export class MenuManagerComponent implements OnInit {

  constructor(private managerService: ManagerService,
     private router: Router ) { }

  ngOnInit(): void {
  }
  
  statisticShow()
  {
    this.router.navigate(["manager/statistics"])
  
  }
}


