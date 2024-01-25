import { Component, NgZone } from '@angular/core';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  errors: string[] | null = null;

  constructor(
    private accountService: AccountService, 
    private router: Router, 
    private formBuilder: FormBuilder  ) { }

  complexPassword = /(?=^.{6,14}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/
  registerForm = this.formBuilder.group({
    displayName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.pattern(this.complexPassword)]]
  })

  async onSubmit() {
    if (this.registerForm.valid) {
      await firstValueFrom(this.accountService.register(this.registerForm.value))
      this.router.navigateByUrl('/table').then(nav => console.log(nav), err => console.error(err))
    }
  }

  validateEmail() {
    const emailField = this.registerForm.get('email')
    if (emailField && emailField.valid && emailField.value) {
      this.accountService.checkEmailExists(emailField.value).subscribe(
        isEmailAlreadyUsed => {
          emailField.setErrors(isEmailAlreadyUsed ? { emailExists: true } : null)
        }
      )
    }
  }

}
