#### MCS 1643 README file
# **Midterm Project : "Arcadish" Zelda**

#### Author: *Adam Satyshev*

##### Modified: *2025-10-30*

<br>

#### Questions for projects: (remove this section for tutorial assignments)
**1. What are the controls to your game? How do we play?**   

> &nbsp;
>You are controlling the Player by using WASD or Arrow Keys as you prefer. You can slash Enemies with the Sword by pressing "Space" button in the direction you are standing. You can press "Esc" button to go to the pause menu.
>
> ---
> 
><i>The "Zelda" font that I used for the game menu - https://fontstruct.com/fontstructions/show/818869/the_legend_of_zelda_nes
>
> Original The Legend of Zelda sprites that my assets were based on :
>
> Link - https://www.spriters-resource.com/nes/legendofzelda/asset/8366/
>
> Dungeon Enemies - https://www.spriters-resource.com/nes/legendofzelda/asset/31806/
>
> Other tools :
> 
> Sound Effects - https://sfxr.me
>
> Tiled - https://www.mapeditor.org
>
> Unity - https://unity.com
>
> Aseprite - https://store.steampowered.com/app/431730/Aseprite/
>
> </i>   
> &nbsp;
 


**2. What creative additions/enhancements did you make? How can we find them?**   

> &nbsp;
><i>I've drawn everything all by myself, well some of the assets were based on the original, but still. I've put some sound effects using jsfxr to create them.</i>   
> &nbsp;
 


**3. Any assets used that you didn't create yourself?**   

> &nbsp;
><i>I created my own assets and models based on the original Zelda game. I used Aseprite to draw sprites of the player, enemies, rooms and everything. For room creation I used program called Tiled, which is a map creator for 2D games.</i>   
> &nbsp;
 


**4. Did you receive help from anyone outside this class or from anyone in this class that is not in a group with you?**   

> &nbsp;
><i>I watched some guides and tutorials on how to make certain things, but rather than that, I haven't recieved any help from someone.</i>   
> &nbsp;
 


**5. Did you get help from any AI Code Assistants?**   

> &nbsp;
><i>Yes, I got help from AI Code Assistants, especially with room generation and enemy AI, as I couldn't understand how to do them the way I want to.</i>   
> &nbsp;
 


**6. Did you get help from any online websites, videos, or tutorials?**   

> &nbsp;
><i>The main tutorial that I followed - https://www.youtube.com/watch?v=F5sMq8PrWuM&list=PL4vbr3u7UKWp0iM1WIfRjCDTI03u43Zfu&index=1
>
> The transition between the rooms - https://www.youtube.com/watch?v=6PzupNzq7ck
>
> Tiled animation guide - https://www.youtube.com/watch?v=ZNEH-rFQ7Ys (It's a tutorial for LÖVE, but there is a part explaining the animation in Tiled).
> </i>   
> &nbsp;
 


**7. What trouble did you have with this project?**   

> &nbsp;
><i>There was a lot of problems that I had to stumble upon. Firstly, I had problem with room generation, especially the code, which was not working properly. So, I had to watch a lot of guides and videos explaining how can I implement this mechaninc into the game. Secondly, I had problem with code structure. I've written a lot of different code, which some of them sometime interfere with each other, causing problems. Later on I used inheritance derived from Enemy.cs to enemy scripts, such as Spider.cs, Slime.cs and Ghost.cs. Thirdly, I had some problems with animations and Unity Animator. It was not a big problem, as I fixed it really quickly, but still, it caused me some trouble. Basically I had problems with tying up the movement and animation, but after watching some guides, it is relatively easy.</i>   
> &nbsp;
 


**8. Is there anything else we should know?**   

> &nbsp;
> <i>Creating a game is really an interesting experience. I enjoyed it a lot, especially the creative part, where I had to draw all of the assets, tiles, making some game decisions and so on. Unfortunately I couldn't implement more ideas that I had, but there is a Final Project for that :) </i>
> &nbsp;

---

The FontStruction “The Legend of Zelda NES” (https://fontstruct.com/fontstructions/show/818869) by “Gwellin” is licensed under a Creative Commons Attribution Non-commercial Share Alike license (http://creativecommons.org/licenses/by-nc-sa/3.0/).
[ancestry]

---

# This starter is based on Jeremy Gibson Bond's MI 231 Starter, https://github.com/MSU-mi231/Unity-3D-Template-2022.3
# (which in turn incorporates some collaborative work and suggestions from me)

# Default GitLab README Content is Below
To make it easy for you to get started with GitLab, here's a list of recommended next steps.

Already a pro? Just edit this README.md and make it your own. Want to make it easy? [Use the template at the bottom](#editing-this-readme)!

## Add your files

- [ ] [Create](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#create-a-file) or [upload](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#upload-a-file) files
- [ ] [Add files using the command line](https://docs.gitlab.com/ee/gitlab-basics/add-file.html#add-a-file-using-the-command-line) or push an existing Git repository with the following command:

```
cd existing_repo
git remote add origin https://gitlab.msu.edu/mi231-f22/templates/unity-project-template.git
git branch -M main
git push -uf origin main
```

## Integrate with your tools

- [ ] [Set up project integrations](https://gitlab.msu.edu/mi231-f22/templates/unity-project-template/-/settings/integrations)

## Collaborate with your team

- [ ] [Invite team members and collaborators](https://docs.gitlab.com/ee/user/project/members/)
- [ ] [Create a new merge request](https://docs.gitlab.com/ee/user/project/merge_requests/creating_merge_requests.html)
- [ ] [Automatically close issues from merge requests](https://docs.gitlab.com/ee/user/project/issues/managing_issues.html#closing-issues-automatically)
- [ ] [Enable merge request approvals](https://docs.gitlab.com/ee/user/project/merge_requests/approvals/)
- [ ] [Automatically merge when pipeline succeeds](https://docs.gitlab.com/ee/user/project/merge_requests/merge_when_pipeline_succeeds.html)

## Test and Deploy

Use the built-in continuous integration in GitLab.

- [ ] [Get started with GitLab CI/CD](https://docs.gitlab.com/ee/ci/quick_start/index.html)
- [ ] [Analyze your code for known vulnerabilities with Static Application Security Testing(SAST)](https://docs.gitlab.com/ee/user/application_security/sast/)
- [ ] [Deploy to Kubernetes, Amazon EC2, or Amazon ECS using Auto Deploy](https://docs.gitlab.com/ee/topics/autodevops/requirements.html)
- [ ] [Use pull-based deployments for improved Kubernetes management](https://docs.gitlab.com/ee/user/clusters/agent/)
- [ ] [Set up protected environments](https://docs.gitlab.com/ee/ci/environments/protected_environments.html)

***

# Editing this README

When you're ready to make this README your own, just edit this file and use the handy template below (or feel free to structure it however you want - this is just a starting point!). Thank you to [makeareadme.com](https://www.makeareadme.com/) for this template.

## Suggestions for a good README
Every project is different, so consider which of these sections apply to yours. The sections used in the template are suggestions for most open source projects. Also keep in mind that while a README can be too long and detailed, too long is better than too short. If you think your README is too long, consider utilizing another form of documentation rather than cutting out information.

## Name
Choose a self-explaining name for your project.

## Description
Let people know what your project can do specifically. Provide context and add a link to any reference visitors might be unfamiliar with. A list of Features or a Background subsection can also be added here. If there are alternatives to your project, this is a good place to list differentiating factors.

## Badges
On some READMEs, you may see small images that convey metadata, such as whether or not all the tests are passing for the project. You can use Shields to add some to your README. Many services also have instructions for adding a badge.

## Visuals
Depending on what you are making, it can be a good idea to include screenshots or even a video (you'll frequently see GIFs rather than actual videos). Tools like ttygif can help, but check out Asciinema for a more sophisticated method.

## Installation
Within a particular ecosystem, there may be a common way of installing things, such as using Yarn, NuGet, or Homebrew. However, consider the possibility that whoever is reading your README is a novice and would like more guidance. Listing specific steps helps remove ambiguity and gets people to using your project as quickly as possible. If it only runs in a specific context like a particular programming language version or operating system or has dependencies that have to be installed manually, also add a Requirements subsection.

## Usage
Use examples liberally, and show the expected output if you can. It's helpful to have inline the smallest example of usage that you can demonstrate, while providing links to more sophisticated examples if they are too long to reasonably include in the README.

## Support
Tell people where they can go to for help. It can be any combination of an issue tracker, a chat room, an email address, etc.

## Roadmap
If you have ideas for releases in the future, it is a good idea to list them in the README.

## Contributing
State if you are open to contributions and what your requirements are for accepting them.

For people who want to make changes to your project, it's helpful to have some documentation on how to get started. Perhaps there is a script that they should run or some environment variables that they need to set. Make these steps explicit. These instructions could also be useful to your future self.

You can also document commands to lint the code or run tests. These steps help to ensure high code quality and reduce the likelihood that the changes inadvertently break something. Having instructions for running tests is especially helpful if it requires external setup, such as starting a Selenium server for testing in a browser.

## Authors and acknowledgment
Show your appreciation to those who have contributed to the project.

## License
For open source projects, say how it is licensed.

## Project status
If you have run out of energy or time for your project, put a note at the top of the README saying that development has slowed down or stopped completely. Someone may choose to fork your project or volunteer to step in as a maintainer or owner, allowing your project to keep going. You can also make an explicit request for maintainers.
