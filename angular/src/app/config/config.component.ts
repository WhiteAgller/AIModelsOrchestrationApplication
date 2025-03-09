import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfigService } from '@proxy/config';
import { ConfigDto } from '@proxy/dto/config';

@Component({
  selector: 'app-config',
  templateUrl: './config.component.html',
  styleUrls: ['./config.component.scss']
})
export class ConfigComponent {
  myForm: FormGroup;
  myConfig: ConfigDto;
  isLoggedIn: boolean = this.authService.isAuthenticated;

  formControls: { label: string, name: string }[] = [
    { label: 'Předplatné', name: 'subscription' },
    { label: 'Skupina prostředků', name: 'resourceGroup' },
    { label: 'Pracovní prostor', name: 'workspace' },
    { label: 'ID pracovního prostoru', name: 'workspaceId' },
    { label: 'ID nájemce', name: 'tenantId' },
    { label: 'Klíč úložiště', name: 'storageKey' },
    { label: 'Název kontejneru pro protokolovací bloky', name: 'logBlobContainerName' },
    { label: 'Název kontejneru pro datové bloky', name: 'dataBlobContainerName' },
    { label: 'Cesta ke složce protokolů', name: 'logFolderPath' },
    { label: 'Cesta ke složce dat', name: 'dataFolderPath' },
    { label: 'ID klienta', name: 'clientId' },
    { label: 'Tajný klíč klienta', name: 'clientSecret' }
  ];

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private configService: ConfigService) { }

  ngOnInit() {
    this.myForm = this.formBuilder.group({});
    this.formControls.forEach(control => {
      this.myForm.addControl(control.name, this.formBuilder.control('', Validators.required));
    });
    
    if(!this.authService.isAuthenticated){
      return;
    }

    this.configService.getByUserId().subscribe(response => {
      this.myConfig = response;
      this.setFormValues();
    });
  }

  setFormValues() {
    Object.keys(this.myForm.controls).forEach(controlName => {
      if (this.myConfig.hasOwnProperty(controlName)) {
        this.myForm.controls[controlName].setValue(this.myConfig[controlName]);
      }
    });
  }

  onSubmit() {
    if (this.myForm.valid) {
      const newObj: ConfigDto = {
        subscription: this.myForm.value.subscription,
        resourceGroup: this.myForm.value.resourceGroup,
        workspace: this.myForm.value.workspace,
        workspaceId: this.myForm.value.workspaceId,
        tenantId: this.myForm.value.tenantId,
        storageKey: this.myForm.value.storageKey,
        logBlobContainerName: this.myForm.value.logBlobContainerName,
        dataBlobContainerName: this.myForm.value.dataBlobContainerName,
        logFolderPath: this.myForm.value.logFolderPath,
        dataFolderPath: this.myForm.value.dataFolderPath,
        clientId: this.myForm.value.clientId,
        clientSecret: this.myForm.value.clientSecret,
      };
      this.configService.getByUserId().subscribe(response => {
        if(response == null){
          this.configService.createByInput(newObj).subscribe();
        }
        else {
          newObj.id = response.id;
          this.configService.update(newObj).subscribe();
        };
      });
    }     
  }
}
