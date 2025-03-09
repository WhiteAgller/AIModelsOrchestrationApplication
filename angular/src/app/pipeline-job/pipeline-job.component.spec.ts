import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PipelineJobComponent } from './pipeline-job.component';

describe('DatasetJobComponent', () => {
  let component: PipelineJobComponent;
  let fixture: ComponentFixture<PipelineJobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PipelineJobComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PipelineJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
