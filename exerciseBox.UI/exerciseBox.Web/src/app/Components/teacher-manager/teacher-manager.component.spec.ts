import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherManagerComponent } from './teacher-manager.component';

describe('TeacherManagerComponent', () => {
  let component: TeacherManagerComponent;
  let fixture: ComponentFixture<TeacherManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeacherManagerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TeacherManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
