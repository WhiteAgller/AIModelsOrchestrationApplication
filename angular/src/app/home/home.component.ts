import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AvaibleConfigService } from '../services/avaibleConfig.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }
  hasConfig: boolean;
  constructor(private authService: AuthService, private router: Router, private avaibleConfigService: AvaibleConfigService) {}

  ngOnInit(){
    this.avaibleConfigService.hasConfig().then(response => {
      this.hasConfig = response;
    });
    
  }

  login() {
    this.authService.navigateToLogin();
  }

  navigateToDataset(){
    this.router.navigateByUrl('/datasets')
  }

  navigateToPipeline(){
    this.router.navigateByUrl('/pipelines_jobs')
  }

  navigateToModels(){
    this.router.navigateByUrl('/models')
  }
  
  navigateToConfig(){
    this.router.navigateByUrl('/config')
  }
}
