import { Component } from '@angular/core';
import { Teacher } from '../../../Entities/Teacher';
import { TeacherService } from '../../../Services/api-services/Teacher';
import { CookieService } from 'ngx-cookie-service';
import { Subject } from '../../../Entities/Subject';
import { Topic } from '../../../Entities/Topic';
import { SchoolLevelService } from '../../../Services/api-services/SchoolLevel.service';
import { SubjectService } from '../../../Services/api-services/Subject.service';
import { TopicService } from '../../../Services/api-services/Topic.service';

@Component({
  selector: 'app-personal-data',
  templateUrl: './personal-data.component.html',
  styleUrls: ['./personal-data.component.css']
})
export class PersonalDataComponent {
  teacher!: Teacher | undefined;
teachersSubjects!: Subject[];
teachersTopics!: Topic[];
teachersSchoolLevels!: string[] | undefined;
  userMail!: string;
  constructor(
    private teacherService: TeacherService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevelService: SchoolLevelService,
    private cookieService: CookieService
  ) {

  }


  async ngOnInit(): Promise<void> {
    this.userMail = this.cookieService.get("userEmail");
    this.teacher = await this.teacherService.getTeacherbyEmail(this.userMail).toPromise();
    this.teachersSubjects = await this.subjectService.getSubjectByTeacherId(this.userMail);
    this.teachersSchoolLevels = await this.schoolLevelService.getSchoolLevelByTeacherId(this.userMail).toPromise();
    console.log(this.teacher);
  }
}
