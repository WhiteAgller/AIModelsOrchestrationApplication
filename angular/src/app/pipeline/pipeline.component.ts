import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatasetService } from '@proxy/dataset';
import { PipelineBodyDto, PipelineEndpointDto } from '@proxy/dto/pipeline';
import { PipelineService } from '@proxy/pipeline';
import { Message, PipelineJobService } from './pipeline-job.service';
import { ExperimentService } from '@proxy/experiment';
import { ValidatorsService } from '../validators/validators.service';
import { FormService } from '../form/form-service';
import { AvaibleConfigService } from '../services/avaibleConfig.service';

export enum ModelType{
  Regrese,
  Klasifikace
}

@Component({
  selector: 'app-pipeline',
  templateUrl: './pipeline.component.html',
  styleUrls: ['./pipeline.component.scss']
})
export class PipelineComponent {
  
  dataSource: PipelineEndpointDto[] = []
  displayedColumns: string[] = ["name", "type","restEndpoint", "delete"]
  myForm: FormGroup;
  myFormSubmit: FormGroup;
  datasetNames = null;
  types = [ModelType.Regrese, ModelType.Klasifikace] 

  constructor(private pipelineService: PipelineService,
              private fb: FormBuilder,
              private datasetSerivce: DatasetService,
              private experimentService: ExperimentService,
              private pipelineJobService: PipelineJobService,
              private validatorsService: ValidatorsService,
              private formSerivce: FormService,
              private avaibleConfigService: AvaibleConfigService){}

  ngOnInit(): void {
    this.myForm = this.fb.group({
      name: ['', Validators.required],
      url: ['', Validators.required],
      type: ['', Validators.required]
    });

    this.myFormSubmit = this.fb.group({
      pipelineUrl: ['', Validators.required],
      datasetName: ['', Validators.required],
      datasetVersion: ['', Validators.required],
      experimentName: ['', Validators.required],
      description: [''],
      displayName: ['', Validators.required],
    });

    this.avaibleConfigService.hasConfig().then(hasConfig => {
      if(!hasConfig){
        return;
      }
      
      this.pipelineService.getList().subscribe(response => {
        this.dataSource = response;
        this.myForm.controls.name.addAsyncValidators([this.validatorsService.uniqueNameValidator(this.dataSource, "name")]);
      });
  
      this.datasetSerivce.getDatasets().subscribe(response => {
        this.datasetNames = response.value
      });
    });
  }
  
  create(): void{
    const input: PipelineEndpointDto = {name: this.myForm.value.name,
                                        type: this.myForm.value.type,
                                        restEndpoint: this.myForm.value.url};
    this.pipelineService.create(input).subscribe(_ => {
      this.pipelineService.getList().subscribe(response => {
        this.dataSource = response;
      });
    });
    this.myForm.reset();
  }

  delete(id: string): void {
    this.pipelineService.delete(id).subscribe(_ => {
      this.pipelineService.getList().subscribe(response => {
        this.dataSource = response;
      });
    })
  }  
  
  getTypeLabel(type: ModelType) {
    switch (type) {
      case ModelType.Klasifikace:
        return "Klasifikace";
      case ModelType.Regrese:
        return "Regrese";
      default:
        throw new Error("Unsupported option");
    }
  }

  onSubmit(): void{
      if (this.myFormSubmit.valid) {
        const url = this.dataSource.find(x => this.myFormSubmit.value.pipelineUrl).restEndpoint
        const body: PipelineBodyDto = {
          pipelineUrl: url,
          datasetName: this.myFormSubmit.value.datasetName,
          datasetVersion: this.myFormSubmit.value.datasetVersion,
          experimentName: this.myFormSubmit.value.experimentName,
          description: this.myFormSubmit.value.description,
          displayName: this.myFormSubmit.value.displayName,
          parameterAssignments: {}
      };

      this.pipelineService.runPipeline(body).subscribe(pipelineResponse => {
        this.experimentService.getExperimentIdByExperimentName(this.myFormSubmit.value.experimentName).subscribe(experimentResponse => {
            const pipelineName = this.dataSource.find(pipeline => pipeline.id === this.myFormSubmit.value.pipelineUrl).name;
            this.sendDataToJob({pipelineId: pipelineResponse.pipelineRunId!,
                           experimentId: experimentResponse,
                           displayName: this.myFormSubmit.value.displayName,
                           pipelineName: pipelineName
                          });
        });
      });  
      // this.experimentService.getExperimentIdByExperimentName(this.myFormSubmit.value.experimentName).subscribe(experimentResponse => {
      //         this.sendData({pipelineId: "9b290cb2-5fb9-4a67-a969-3bb710fd0166",
      //                        experimentId: experimentResponse,
      //                        displayName: this.myFormSubmit.value.displayName});
      // });
    }
  }  

  private sendDataToJob(message: Message) {
    this.pipelineJobService.changeMessage(message);
    this.myFormSubmit = this.formSerivce.resetFormGroup(this.myFormSubmit);
  }
}

