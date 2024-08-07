import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseSheetGenerationComponent } from './exercise-sheet-generation.component';

describe('ExerciseSheetGenerationComponent', () => {
  let component: ExerciseSheetGenerationComponent;
  let fixture: ComponentFixture<ExerciseSheetGenerationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExerciseSheetGenerationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExerciseSheetGenerationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
