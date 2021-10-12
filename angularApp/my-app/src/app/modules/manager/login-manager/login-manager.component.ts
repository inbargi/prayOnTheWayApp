import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ManagerService } from 'src/app/shared/services/manager.service';


@Component({
  selector: 'app-login-manager',
  templateUrl: './login-manager.component.html',
  styleUrls: ['./login-manager.component.css']

})
export class LoginManagerComponent implements OnInit {
  loginManagerFrm!: FormGroup
  constructor(private managerService: ManagerService,
    private router: Router 
  
    ) { }
    
  ngOnInit(): void {
   this.loginManagerFrm=new FormGroup({
      managerName:new FormControl('',Validators.pattern('[a-zA-Z0-9]*')),
      password: new FormControl('')
   })
    
  }

  loginManager() {
    this.managerService.login( this.loginManagerFrm.get('managerName')?.value,this.loginManagerFrm.get('password')?.value ).subscribe(
      res => {
        if (res) {
          console.log(res);
          this.router.navigate(["manager/menu-manager"])

      
        }
        else console.error("not correct")
      }
    )
  }

}
