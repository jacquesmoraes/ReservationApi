import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  returnUrl: string;
constructor(private accountService: AccountService, private router : Router, private formBuilder : FormBuilder, 
  private activatedRoute: ActivatedRoute){
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl']
  }

loginForm = this.formBuilder.group({
  email: ['', [Validators.required, Validators.email]],
  password: ['', Validators.required]
})


onSubmit(){
  this.accountService.login(this.loginForm.value).subscribe({
    next: () => this.router.navigateByUrl('/table')
  })
}

}
 