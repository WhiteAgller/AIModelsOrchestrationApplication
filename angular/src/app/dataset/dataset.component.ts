import { AuthService } from '@abp/ng.core';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DatasetService } from '@proxy/dataset';
import { DatasetPutRequesetDto } from '@proxy/dto/dataset';
import { AvaibleConfigService } from '../services/avaibleConfig.service';
import { FormService } from '../form/form-service';


export interface TableData{
  name: string,
  dataType: string,
  latestVersion: string
}

@Component({
  selector: 'app-dataset',
  templateUrl: './dataset.component.html',
  styleUrls: ['./dataset.component.scss']
})
export class DatasetComponent {
  dataSource = null;
  displayedColumns: Array<string> = ["name", "dataType", "latestVersion"];
  myForm: FormGroup;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private fb: FormBuilder,
              private datasetService: DatasetService,
              private authService: AuthService,
              private avaibleConfigService: AvaibleConfigService,
              private formService: FormService){ }

  async ngOnInit() {
    this.myForm = this.fb.group({
      name: ['', Validators.required],
      dataType: ['', Validators.required],
      version: ['', Validators.required],
      description: [''],
      url: ['', Validators.required]
    });

    if(!this.authService.isAuthenticated){
      return;
    }
    
    this.avaibleConfigService.hasConfig().then(hasConfig => {
      if(!hasConfig){
        return;
      }
      this.getData();
    });
  }

  getData(){
    this.datasetService.getDatasets().subscribe(response => {
      const source = response.value;
      const tableSource: TableData[] = source.map((data) => {
        return Object.assign(
          {
            name: data.name,
            dataType: data.properties.dataType,
            latestVersion: data.properties.latestVersion
          }
        );
      });
      this.dataSource = new MatTableDataSource(tableSource);
      this.dataSource.sort = this.sort;
    });
  }

  onSubmit() {
    if(!this.authService.isAuthenticated){
      return;
    }

    if (this.myForm.valid) {
      const body: DatasetPutRequesetDto = {
        dataType: this.myForm.value.dataType,
        description:  this.myForm.value.description,
        newDatasetName:  this.myForm.value.name,
        newDatasetVersion:  this.myForm.value.version,
        dataStoreUrl:  this.myForm.value.url
      };
      this.datasetService.createOrUpdateDatasetByInput(body).subscribe(response => {
        this.formService.resetFormGroup(this.myForm);
        this.getData();
      });
    }
  }
}
